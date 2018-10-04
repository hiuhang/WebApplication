GO
CREATE DATABASE Test;
GO

use Test;

create table CreditCard (
	type			VARCHAR(30)	,
	cardno			VARCHAR(16)	not null unique,
	expDate			DATETIME	not null,
	ccvNumber		INT			not null,
)	

INSERT into CreditCard VALUES ('Amex', '312412341234123','2020-08-11',591);
INSERT into CreditCard VALUES ('Mastercard', '5123123412341234','2019-09-01',312);
INSERT into CreditCard VALUES ('JCB', '3124123412341234','2020-08-11',123);
INSERT into CreditCard VALUES ('Visa', '4124123412341234','2020-08-11',111);