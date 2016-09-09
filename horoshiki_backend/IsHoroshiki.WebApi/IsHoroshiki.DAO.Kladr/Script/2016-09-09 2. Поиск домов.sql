USE [Kladr]
GO

CREATE procedure [dbo].[usp_get_range_number](@address varchar(4000), @CODE varchar(19), @OCATD varchar(11)) 
AS
declare @SQL varchar(4000);

create table #numbers(counter int)
declare @count int
set @count = 1
while @count < 5000 
	begin
		insert into #numbers values(@count)
		set @count = @count + 1
	end


set @SQL='select Building = counter, Corpus = convert(varchar(50), null), Construction = convert(varchar(50), null), CODE = ''' + @CODE + ''', OCATD = ''' + @OCATD + ''' FROM #numbers where '+replace(replace(replace(replace(replace(replace(@address,'(',' between '),'-',' and '),',',' or '),')',''),'Н', ' counter '+'%2=1 and'+' counter '),'Ч', ' counter '+'%2=0 and'+' counter ');
if charindex('between', @SQL) = 0 
	set @SQL = replace(@SQL, 'where', 'where counter between ')
exec(@SQL)

GO



CREATE procedure [dbo].[usp_set_build_parsing](@address varchar(4000), @CODE varchar(19), @OCATD varchar(11)) 
AS
BEGIN

declare @build varchar(50), @comma int,
		@Corpus_index int, @Construction_index int, @Building varchar(50), @Corpus varchar(50), @Construction varchar(50),
		@Corpus_index_end int


create table #address
(
	counter int identity(1, 1) ,
	CODE varchar(19), 
	OCATD varchar(11), 
	Building varchar(50), 
	Corpus varchar(50), 
	Construction varchar(50)
)

set @address=ltrim(rtrim(@address))

while len(@address) > 0
begin
	set @build = ''
	set @Building = null
	set @Corpus = null
	set @Construction = null

	set @comma = charindex(',', @address)	
	if @comma <> 0 
		set @build = substring(@address, 1, @comma - 1)
	else
	begin
		set @build = @address 
		set @address = ''	
	end
	  set @address = substring(@address, @comma + 1, 3000)	

	-- дианазоны (четные/нечетные) номера зданий
	if charindex('-', @build) <> 0
	begin 
		if len(@build) > 1 -- Исключаються варианты 37/2,Ч
			insert into #address(Building, Corpus, Construction, CODE, OCATD)
			exec dbo.usp_get_range_number @build, @CODE, @OCATD
	end
	else
	begin

	 -- корпус зданий
	 set @Corpus_index = charindex('к', @build)	
	 set @Construction_index = charindex('стр', @build)

	 if @Construction_index = 0 set @Corpus_index_end = 4000 else set @Corpus_index_end = @Construction_index - 1

	 if @Corpus_index <> 0 
	 begin
		set @Building = substring(@build, 1, @Corpus_index - 1)
		set @Corpus = substring(@build, @Corpus_index + 1, @Corpus_index_end - @Corpus_index)
	 end

	 -- строение зданий
	 if @Construction_index <> 0 
	 begin
		if isnull(@Building, '') = '' set @Building = substring(@build, 1, @Construction_index - 1)
		set @Construction = substring(@build, @Construction_index + 3, 4000)
	 end

	 if isnull(@Building, '') = '' set @Building = @build

	 insert into #address(Building, Corpus, Construction, CODE, OCATD)
	 select @Building, @Corpus, @Construction, @CODE, @OCATD
	end -- без 'Ч', 'Н'

end

select * from  #address;

drop table #address;

END;
GO



CREATE procedure [dbo].[usp_get_build](@regionId varchar(19), @query varchar(256), @limit int) 
AS
BEGIN
	IF @limit = 0	
		SET @limit = 10;

	SET @regionId = LEFT(@regionId, 15);

	CREATE TABLE #Result
	(
		[SOCR] [varchar](10) NULL,
		[CODE] [varchar](19) NULL,
		[INDEX] [varchar](6) NULL,
		[GNINMB] [varchar](4) NULL,
		[UNO]	[varchar](4)  NULL,
		[OCATD] [varchar](11) NULL,
		[Building] [varchar](50),
		[Corpus]   [varchar](50), 
		[Construction] [varchar](50),
		[counter] int
	)

	CREATE TABLE #Doma
	(
		[NAME] [varchar](40) NULL,
		[KORP] [varchar](10) NULL,
		[SOCR] [varchar](10) NULL,
		[CODE] [varchar](19) NULL,
		[INDEX] [varchar](6) NULL,
		[GNINMB] [varchar](4) NULL,
		[UNO]	[varchar](4)  NULL,
		[OCATD] [varchar](11) NULL
	)

	--находим все дома для указанного региона
	INSERT INTO #Doma
	SELECT
		*
	FROM
		[dbo].DOMA
	WHERE 
		LEFT(CODE, 15) = @regionId


	DECLARE @NAME VARCHAR (40)
	DECLARE @CODE VARCHAR (19)
	DECLARE @OCATD VARCHAR (11)

	DECLARE @CURSOR CURSOR
	SET @CURSOR  = CURSOR SCROLL
	FOR
		SELECT  
				[NAME], 
				[CODE], 
				[OCATD]
		FROM  
	  			#Doma 
	
	OPEN @CURSOR

	FETCH NEXT FROM @CURSOR INTO @NAME, @CODE, @OCATD
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- парсим все дома в таблицу #Result
		INSERT INTO #Result([counter], [CODE], [OCATD], [Building], [Corpus], [Construction])
		exec [dbo].[usp_set_build_parsing] @NAME, @CODE, @OCATD 

		FETCH NEXT FROM @CURSOR INTO @NAME, @CODE, @OCATD
	END
	CLOSE @CURSOR

	--проставляем недостающие столбцы в #Result
	UPDATE 
		#Result
	SET
		[SOCR] = d.[SOCR], 
		[INDEX] =  d.[INDEX],
		[GNINMB] =  d.[GNINMB],
		[UNO] =  d.[UNO],
		[OCATD] =  d.[OCATD]
	FROM
		#Doma d
	WHERE 
		#Result.[CODE] = d.[CODE]

	--возвращаем результат запроса, если был запрощен какой то дом, то ищем для него по началу строки
	IF (LEN(@query) > 0)
	BEGIN
		SELECT  
			* 
		FROM    
			( 
			  SELECT 
					ROW_NUMBER() OVER (ORDER BY [CODE]) AS RowNum,
					* 
 			   FROM 
					#Result 
			  WHERE 
					[Building] like @query + '%'
			) AS RowConstrainedResult
		WHERE
			 RowNum < @limit
	   ORDER BY 
			 RowNum;
	END
	ELSE
	BEGIN
		SELECT  
			* 
		FROM    
			( 
			  SELECT ROW_NUMBER() OVER (ORDER BY [CODE]) AS RowNum, * FROM #Result 
			) AS RowConstrainedResult
		WHERE
			 RowNum < @limit
	   ORDER BY 
			 RowNum;
	END;

    DROP TABLE #Doma;
	DROP TABLE #Result;
END;