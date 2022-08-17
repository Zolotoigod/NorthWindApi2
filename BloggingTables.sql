CREATE TABLE Articles
(
	article_Id INT PRIMARY KEY,
	article_Title VARCHAR(128),
	article_Text VARCHAR,
	publish_Date DATETIME,
	employee_Id INT NOT NULL,
);

CREATE TABLE Comments
(
	comment_Id INT PRIMARY KEY,
	article_Id INT NOT NULL,
	comment VARCHAR,
	created_Date DATETIME,
	FOREIGN KEY (article_Id) REFERENCES articles(article_Id),
);

CREATE TABLE Links
(
	link_Id INT PRIMARY KEY,
	article_Id INT,
	product_Id INT,
	FOREIGN KEY (article_Id) REFERENCES articles(article_Id),
);