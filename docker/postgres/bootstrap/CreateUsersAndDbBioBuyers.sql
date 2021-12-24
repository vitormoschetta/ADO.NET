-- Script for biobuyers service database bootstrap
-- Creates DDL and DML users and grants its respective privileges
-- Must run as an administrator user:
-- psql -h <hostname> -p <port> -U <admin user> < CreateUsersAndDb.sql


-- Creates database and schema
SELECT 'CREATE DATABASE integration'
    WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'integration')\gexec
\connect integration;

CREATE SCHEMA biobuyers;

-- Creates users
CREATE USER biobuyers_ddl WITH ENCRYPTED PASSWORD 'bionexo'; -- *** CHANGE PASSWORD IN PRODUCTION ENVIRONMENT ***
CREATE USER biobuyers_dml WITH ENCRYPTED PASSWORD 'bionexo'; -- *** CHANGE PASSWORD IN PRODUCTION ENVIRONMENT ***
CREATE USER biobuyers_readonly WITH ENCRYPTED PASSWORD 'bionexo'; -- *** CHANGE PASSWORD IN PRODUCTION ENVIRONMENT ***


-- DDL privileges
GRANT CONNECT ON DATABASE integration TO biobuyers_ddl;
GRANT CREATE, USAGE ON SCHEMA biobuyers TO biobuyers_ddl;

-- DML privileges
GRANT CONNECT ON DATABASE integration TO biobuyers_dml;
GRANT CONNECT ON DATABASE integration TO biobuyers_readonly;
GRANT USAGE ON SCHEMA biobuyers TO biobuyers_dml;
GRANT USAGE ON SCHEMA biobuyers TO biobuyers_readonly;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA biobuyers TO biobuyers_dml;
GRANT SELECT ON ALL TABLES IN SCHEMA biobuyers TO biobuyers_readonly;

-- SET search_path
ALTER ROLE biobuyers_ddl IN DATABASE integration SET search_path = biobuyers;
ALTER ROLE biobuyers_dml IN DATABASE integration SET search_path = biobuyers;
ALTER ROLE biobuyers_readonly IN DATABASE integration SET search_path = biobuyers;
