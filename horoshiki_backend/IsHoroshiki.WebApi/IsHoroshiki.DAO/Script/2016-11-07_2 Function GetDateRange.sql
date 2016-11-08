CREATE FUNCTION [dbo].[GetDateRange]
(     
      @Increment              CHAR(1),
      @StartDate              DATETIME,
      @EndDate                DATETIME
)
RETURNS  
@SelectedRange TABLE
(
	[Date] DATETIME
)
AS 
BEGIN
      WITH cteRange (DateRange) AS (
            SELECT @StartDate
            UNION ALL
            SELECT 
                  CASE
                        WHEN @Increment = 'd' THEN DATEADD(dd, 1, DateRange)
                        WHEN @Increment = 'w' THEN DATEADD(ww, 1, DateRange)
                        WHEN @Increment = 'm' THEN DATEADD(mm, 1, DateRange)
                  END
            FROM cteRange
            WHERE DateRange <= 
                  CASE
                        WHEN @Increment = 'd' THEN DATEADD(dd, -1, @EndDate)
                        WHEN @Increment = 'w' THEN DATEADD(ww, -1, @EndDate)
                        WHEN @Increment = 'm' THEN DATEADD(mm, -1, @EndDate)
                  END)
          
      INSERT INTO @SelectedRange 
	  (
		[Date]
	  )
      SELECT 
		DateRange
      FROM 
		cteRange
      OPTION (MAXRECURSION 1000);
      RETURN
END
GO