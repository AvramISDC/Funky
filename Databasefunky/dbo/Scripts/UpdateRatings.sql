--for each restaurant update the ratings based on comments for it

UPDATE FR2
SET FR2.AverageStars = FR1.AverageStars
FROM Funkyrestaurants FR2
INNER JOIN (
	SELECT C.[Restaurant ID] AS ID, AVG(Ratings) AS AverageStars 
	FROM Comments C
	GROUP BY C.[Restaurant ID])
FR1
ON FR1.ID = FR2.ID