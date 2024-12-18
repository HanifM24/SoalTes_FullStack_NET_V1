
--DDL
use myDB
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[customers]
GO
CREATE TABLE [dbo].[customers](
	customer_id INT unique not null,
	customer_name varchar(100),
	PRIMARY KEY (customer_id)
)

--DDL
use myDB
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[transactions]') AND type in (N'U'))
DROP TABLE [dbo].[transactions]
GO
CREATE TABLE [dbo].[transactions](
	transactions_id int unique not null,
	customer_id INT not null,
	amount INT,
	transaction_date DATETIME,
	 FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
)



--INITIAL DATA
INSERT INTO [dbo].[customers]  (
customer_id,
customer_name
)
VALUES 
(1, 'Andi'),
(2, 'Rama'),
(3, 'Tina')

--INITIAL DATA
INSERT INTO [dbo].[transactions]  (
transactions_id,
customer_id,
amount,
transaction_date
)
VALUES 
(1,1, 12000 ,'2024-01-02' ),
(2,2, 6000 ,'2024-02-02' ),
(3,2, 23000 ,'2024-03-02' ),
(4,2, 18000 ,'2024-04-02' ),
(5,1, 7000 ,'2024-05-02' )


--a. Berikan query SQL untuk mendapatkan daftar pelanggan yang belum melakukan transaksi dalam 6 bulan terakhir.
SELECT 
c.customer_id as customerid,
c.customer_name as customername
FROM [dbo].[customers] c 
WHERE c.customer_id not in
(SELECT customer_id FROM [dbo].[transactions] WHERE DATEDIFF(month, transaction_date, getdate())<=6 GROUP BY customer_id)
  

--b. Berikan query total amount masing masing pelanggan
SELECT 
t.customer_id AS customerid,
c.customer_name AS customername, 		
SUM(t.amount) as Total
FROM transactions t
INNER JOIN customers c on t.customer_id = c.customer_id
GROUP by t.customer_id , c.customer_name


