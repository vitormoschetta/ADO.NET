-- ***************************** client_settings *****************************

insert
	into
	biobuyers.client_settings (id,
	origin_id,
	cnpj,
	send_operation,
	return_operation,
	quote_deadline,
	contract_use,
	quote_expiration_time,
	register_supplier,
	order_group_by,
	audience,
	client_id,
	client_secret,
	grant_type,
	schema_data_table,
	skalena_url_base)
values ('50d14739-ec5d-44ca-b696-51742f2622de',
'5',
'99999999999999',
'WASE',
1,
'30.00:00:00.000',
false,
'24:00:00.000',
true,
1,
'openid bionexo-soap',
'dml0b3Jtb3NjaGV0dGFAaG90bWFpbC5jb206Ymlvbm',
'OUZabDR1azhvcTpiaW9uZv',
'client_credentials',
'TASY',
'https://api-sandbox.platform.bio/v1');



-- ***************************** product_category *****************************

insert
	into
	biobuyers.product_category(id,
	code_erp,
	description_erp,
	code_bio,
	description_bio,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ec',
'10',
'category test WIP',
'100',
'category teste Bio',
(select cs.id from client_settings as cs limit 1) );


insert
	into
	biobuyers.product_category(id,
	code_erp,
	description_erp,
	code_bio,
	description_bio,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ed',
'11',
'category test WIP 02',
'100',
'category teste Bio 02',
(select cs.id from client_settings as cs limit 1) );


insert
	into
	biobuyers.product_category(id,
	code_erp,
	description_erp,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ee',
'12',
'category test WIP 03',
(select cs.id from client_settings as cs limit 1) );



-- ***************************** product_unit_measurement *****************************

insert
	into
	biobuyers.product_unit_measurement (id,
	code_erp,
	description_erp,
	code_bio,
	description_bio,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ec',
'11',
'unit test WIP',
'1',
'uni teste Bio',
(select	cs.id from client_settings as cs limit 1) );

insert
	into
	biobuyers.product_unit_measurement (id,
	code_erp,
	description_erp,
	code_bio,
	description_bio,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ed',
'12',
'unit test WIP 02',
'1',
'uni teste Bio 02',
(select	cs.id from client_settings as cs limit 1) );


insert
	into
	biobuyers.product_unit_measurement (id,
	code_erp,
	description_erp,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ee',
'13',
'unit test WIP 03',
(select	cs.id from client_settings as cs limit 1) );



-- ***************************** product *****************************

insert
	into
	biobuyers.product(id,
	active,
	code,
	"name",
	description,
	packing,
	quantity_packing,
	favorite_brand_alternative,
	standard_brand_active,
	standard_brand_code,
	standard_brand_name,
	status,
	client_settings_id,
	product_category_id,
	product_unit_measurement_id)
values( '46d9814c-3208-434e-bee8-56682f9134ed',
'S',
'12345',
'Product test WIP',
'Product registration for tests operation WIP',
'Und',
'10',
'N',
'N',
'123',
'Marca Homologada',
2,
(select	cs.id from client_settings as cs limit 1),
(select	pc.id from product_category as pc limit 1),
(select	pum.id from product_unit_measurement as pum limit 1));


insert
	into
	biobuyers.product(id,
	active,
	code,
	"name",
	description,
	packing,
	quantity_packing,
	favorite_brand_alternative,
	standard_brand_active,
	standard_brand_code,
	standard_brand_name,
	status,
	client_settings_id,
	product_category_id,
	product_unit_measurement_id)
values( '46d9814c-3208-434e-bee8-56682f9134ee',
'S',
'12346',
'Product test WIP',
'Product registration for tests operation WIP',
'Und',
'10',
'N',
'N',
'123',
'Marca Homologada',
2,
(select	cs.id from client_settings as cs limit 1),
'46d9814c-3208-434e-bee8-56682f9134ed',
'46d9814c-3208-434e-bee8-56682f9134ed');


insert
	into
	biobuyers.product(id,
	active,
	code,
	"name",
	description,
	packing,
	quantity_packing,
	favorite_brand_alternative,
	standard_brand_active,
	standard_brand_code,
	standard_brand_name,
	status,
	client_settings_id,
	product_category_id,
	product_unit_measurement_id)
values( '46d9814c-3208-434e-bee8-56682f9134ef',
'S',
'12347',
'Product test WIP',
'Product registration for tests operation WIP',
'Und',
'10',
'N',
'N',
'123',
'Marca Homologada',
1,
(select	cs.id from client_settings as cs limit 1),
'46d9814c-3208-434e-bee8-56682f9134ed',
'46d9814c-3208-434e-bee8-56682f9134ed');



-- ***************************** payment_method *****************************

insert
	into
	biobuyers.payment_method (id,
	code_erp,
	description_erp,
	code_bio,
	description_bio,
	client_settings_id)
values('46d9814c-3208-434e-bee8-56682f9134ec',
'1',
'payment method test',
'11',
'payment method teste Bio',
(select	cs.id from client_settings as cs limit 1) );



-- ***************************** quote *****************************

insert
	into
	biobuyers."quote" (id,
	"number",
	title,
	contact,
	expiration_date ,
	currency ,
	remark ,
	terms ,
	quote_type ,
	cod_estab,
	creation_date ,
	status ,
	ie_updated_at,
	client_settings_id,
	payment_method_id)
values( '46d9814c-3208-434e-bee8-56682f9134ed',
'144',
'PDC de Teste BioBuyers',
'1',
'2021-09-21T17:00:00',
'Real',
'Observações referente ao PDC',
'',
'100',
'',
'2021-07-20T17:00:00',
1,
'2021-09-21T17:00:00',
(select	cs.id from client_settings as cs limit 1),
(select	pm.id from payment_method as pm limit 1) );


insert
	into
	biobuyers."quote" (id,
	"number",
	title,
	contact,
	expiration_date ,
	currency ,
	remark ,
	terms ,
	quote_type ,
	cod_estab,
	creation_date ,
	status ,
	ie_updated_at,
	client_settings_id,
	payment_method_id)
values( '46d9814c-3208-434e-bee8-56682f9134ef',
'145',
'PDC de Teste BioBuyers 2',
'1',
'2021-09-21T17:00:00',
'Real',
'Observações referente ao PDC 2',
'',
'100',
'',
'2021-07-20T17:00:00',
1,
'2021-09-21T17:00:00',
(select	cs.id from client_settings as cs limit 1),
(select	pm.id from payment_method as pm limit 1) );



-- ***************************** quote_item *****************************

insert
	into
	biobuyers.quote_item (id,
	number,
	product_code ,
	product_description ,
	product_packing ,
	product_quantity ,
	status,
	product_price ,
	quote_number,
	quote_id)
values( '46d9814c-3208-434e-bee8-56682f9134ed',
'1',
'12345',
'Test Product 00',
'UND',
'300',
 1,
'149.00',
'144',
(select	q.id from "quote" as q where q.number = '144') );


insert
	into
	biobuyers.quote_item (id,
	number,
	product_code ,
	product_description ,
	product_packing ,
	product_quantity ,
    status,
    product_price ,
	quote_number,
	quote_id)
values( '46d9814c-3208-434e-bee8-56682f9134ef',
'2',
'12346',
'Test Product 01',
'UND',
'500',
1,
'2.50',
'144',
(select	q.id from "quote" as q where q.number = '144') );



-- ***************************** quote_item_delivery *****************************

insert
	into
	biobuyers.quote_item_delivery (id,
	product_quantity,
	delivery_date,
	quote_item_id)
values('46d9814c-3208-434e-bee8-56682f9134ef',
150,
'2021-09-21T17:00:00',
(select qi.id from 	quote_item as qi where qi.number = '1') );


insert
	into
	biobuyers.quote_item_delivery (id,
	product_quantity,
	delivery_date,
	quote_item_id)
values('16d9814c-3208-434e-bee8-56682f9134ef',
150,
'2021-10-21T17:00:00',
(select qi.id from 	quote_item as qi where qi.number = '1') );


insert
	into
	biobuyers.quote_item_delivery (id,
	product_quantity,
	delivery_date,
	quote_item_id)
values('46d9814c-3208-434e-bee8-56682f9134ee',
300,
'2021-09-21T17:00:00',
(select qi.id from 	quote_item as qi where qi.number = '2') );


insert
	into
	biobuyers.quote_item_delivery (id,
	product_quantity,
	delivery_date,
	quote_item_id)
values('26d9814c-3208-434e-bee8-56682f9134ef',
100,
'2021-10-21T17:00:00',
(select qi.id from 	quote_item as qi where qi.number = '2') );


insert
	into
	biobuyers.quote_item_delivery (id,
	product_quantity,
	delivery_date,
	quote_item_id)
values('26d9814c-3208-434e-bee8-56682f9134ee',
100,
'2021-11-21T17:00:00',
(select qi.id from 	quote_item as qi where qi.number = '2') );



-- ***************************** quote_item_response *****************************

INSERT INTO biobuyers.quote_item_response(
	id,
	selected_item,
	product_code,
	product_quantity,
	product_description,
	unit_price,
	total_price,
	manufacturer,
	query_supplier,
	supplier_cnpj,
	article_id,
	"comment",
	error_message,
	order_number,
	quote_number,
	pdc_bio,
	status,
	quote_item_id,
	payment_method_id)
VALUES(
	'36d9814c-3208-434e-bee8-56682f9134ed',
	true,
	'12345',
	300,
	'',
	150.00,
	15000.00,
	'MARCA TESTE',
	null,
	'99999999000199',
	'',
	'comentario teste.',
	null,
	null,
	'144',
	'1001',
	1,
	'46d9814c-3208-434e-bee8-56682f9134ed',
	'46d9814c-3208-434e-bee8-56682f9134ec');


INSERT INTO biobuyers.quote_item_response(
	id,
	selected_item,
	product_code,
	product_quantity,
	product_description,
	unit_price,
	total_price,
	manufacturer,
	query_supplier,
	supplier_cnpj,
	article_id,
	"comment",
	error_message,
	order_number,
	quote_number,
	pdc_bio,
	status,
	quote_item_id,
	payment_method_id)
VALUES(
	'36d9814c-3208-434e-bee8-56682f9134ef',
	true,
	'12346',
	500,
	'',
	2.50,
	1250.00,
	'MARCA TESTE',
	null,
	'99999999000198',
	'',
	'comentario teste.',
	null,
	null,
	'144',
	'1001',
	1,
	'46d9814c-3208-434e-bee8-56682f9134ef',
	'46d9814c-3208-434e-bee8-56682f9134ec');



-- ***************************** quote_item_response_delivery *****************************

INSERT INTO biobuyers.quote_item_response_delivery(
	id,
	product_quantity,
	delivery_date,
	quote_item_response_id)
VALUES(
	'38cea5e6-4c2a-4ac5-80c3-4324e54c84a7',
	150,
	'2022-02-21 00:00:00',
	'36d9814c-3208-434e-bee8-56682f9134ed');


INSERT INTO biobuyers.quote_item_response_delivery(
	id,
	product_quantity,
	delivery_date,
	quote_item_response_id)
VALUES(
	'efbc63e6-e0dd-48c0-8bc4-611d3e3895c4',
	150,
	'2022-03-21 00:00:00',
	'36d9814c-3208-434e-bee8-56682f9134ed');


INSERT INTO biobuyers.quote_item_response_delivery(
	id,
	product_quantity,
	delivery_date,
	quote_item_response_id)
VALUES(
	'e6eacd4b-efe1-4e51-81d5-2adb6f60e6e3',
	200,
	'2022-02-21 00:00:00',
	'36d9814c-3208-434e-bee8-56682f9134ef');


INSERT INTO biobuyers.quote_item_response_delivery(
	id,
	product_quantity,
	delivery_date,
	quote_item_response_id)
VALUES(
	'8215f7cf-44a9-4428-a491-1bbfceb15d56',
	200,
	'2022-03-21 00:00:00',
	'36d9814c-3208-434e-bee8-56682f9134ef');


INSERT INTO biobuyers.quote_item_response_delivery(
	id,
	product_quantity,
	delivery_date,
	quote_item_response_id)
VALUES(
	'a789260b-4c2e-447a-a9cf-88f8e9f9d045',
	100,
	'2022-04-21 00:00:00',
	'36d9814c-3208-434e-bee8-56682f9134ef');



-- ***************************** quote_item_response_cancel *****************************

INSERT INTO biobuyers.quote_item_response_cancel(
	id,
	cancel_erp_id,
	status,
	order_number,
	cancel_date,
	quote_item_response_id)
VALUES(
	'46d9814c-3208-434e-bee8-56682f9134ed',
	123,
	1,
	1,
	'01/01/2021',
	'36d9814c-3208-434e-bee8-56682f9134ed');

