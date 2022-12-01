-- Database: OnlineRegistration

-- DROP DATABASE IF EXISTS "OnlineRegistration";

CREATE DATABASE "OnlineRegistration"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Ukrainian_Ukraine.1251'
    LC_CTYPE = 'Ukrainian_Ukraine.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
CREATE TABLE person (
  id SERIAL PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  address VARCHAR(100)NOT NULL,
  phone VARCHAR(15) NOT NULL	
);	

INSERT INTO person(name, address, phone)
VALUES('Christina Scott','Studio 35 Tom Green B10 9JS', '(408)-4442-1234'),
      ('Victoria Ward','Studio 00m Anderson Springs LL55 4TE', '(408)-1222-1234'),
      ('Mary Cooper','Studio 35 Tom Green B10 9JS', '(408)-6812-1234');


CREATE TABLE doctor (
  id SERIAL PRIMARY KEY,
  specielization VARCHAR(100),
  person_id int Not null,
  FOREIGN KEY (person_id)
  REFERENCES person (id)	
);

INSERT INTO doctor(person_id, specielization)
VALUES((select "id" from public."person" where "id" = 1),'okulist,'),
((select "id" from public."person" where "id" = 2),'surgeon'),
((select "id" from public."person" where "id" = 3),'pediatrician')

CREATE TABLE hospital (
  id SERIAL PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  address VARCHAR(100)NOT NULL	
);	

CREATE TABLE stuff (
  id SERIAL PRIMARY KEY,
  doctor_id int Not null,
  FOREIGN KEY (doctor_id)
  REFERENCES doctor (id),
  hospital_id int Not null,
  FOREIGN KEY (hospital_id)
  REFERENCES hospital (id)
);	

CREATE TABLE patient (
  id SERIAL PRIMARY KEY,
  person_id int Not null,
  FOREIGN KEY (person_id)
  REFERENCES person (id),
  family_doctor_id int Not null,
  FOREIGN KEY (family_doctor_id)
  REFERENCES doctor(id)
);

CREATE TABLE appointment (
  id SERIAL PRIMARY KEY,
  date_time DATE Not null,
  patient_id int Not null,
  FOREIGN KEY (patient_id)
  REFERENCES patient (id),
  doctor_id int Not null,
  FOREIGN KEY (doctor_id)
  REFERENCES doctor(id)
);
