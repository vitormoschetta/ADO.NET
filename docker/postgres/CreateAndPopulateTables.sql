CREATE SCHEMA adonet;

-- CREATE tables
CREATE TABLE adonet.product (
	id serial PRIMARY KEY,
    "name" text NOT NULL,
    price decimal(8,3) NOT NULL,     
	UNIQUE ("name")
);

CREATE TABLE adonet.order (
	id serial PRIMARY KEY,
    "date" timestamp default NULL	
);

CREATE TABLE adonet.order_product (
	id serial PRIMARY KEY,
    order_id integer REFERENCES adonet.order (id),
    product_id integer REFERENCES adonet.product (id)
);


-- Seeds
insert into adonet.product ("name", price) values('leite', 5.99);
insert into adonet.product ("name", price) values('arroz', 21.50);	
insert into adonet.product ("name", price) values('acucar', 6.75);	

insert into adonet.order ("date") values(to_timestamp('01/01/2022 10:59:00', 'MM/DD/YYYY HH24:MI:SS'));	
insert into adonet.order ("date") values(to_timestamp('02/01/2022 12:00:00', 'MM/DD/YYYY HH24:MI:SS'));	

insert into 
	adonet.order_product (order_id, product_id) 
	values
	(
		(select o.id from adonet.order o limit 1),
		(select p.id from adonet.product p where p.name = 'leite')
	),	
	(
		(select o.id from adonet.order o limit 1),
		(select p.id from adonet.product p where p.name = 'arroz')
	),
	(
		(select o.id from adonet.order o order by o.id desc limit 1),
		(select p.id from adonet.product p where p.name = 'arroz')
	),
	(
		(select o.id from adonet.order o order by o.id desc limit 1),
		(select p.id from adonet.product p where p.name = 'acucar')
	)
