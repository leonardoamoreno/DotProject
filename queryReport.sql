

select tabelaFinal.Name as UserName,
ROUND(((CAST(Done as DECIMAL)*100)/(CAST(Total AS DECIMAL))),1) as PercentageComplete,
Done,
NotCompleted,
Total
FROM(
SELECT
	u.Name, 	
	SUM(CASE WHEN Status = 1 THEN 1 ELSE 0 END) as Done,
	SUM(CASE WHEN Status = 0 THEN 1 ELSE 0 END) as NotCompleted,
	count(*) as Total
	from Tasks t 
	inner join Projects p on t.ProjectId = p.Id
	inner join Users u on p.UserId = u.Id
	--where t.Status = 1
	group by u.Name
) tabelaFinal


