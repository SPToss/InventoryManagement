CREATE TABLE PRODUCT_STATUS(
ID INT NOT NULL AUTO_INCREMENT,
DESCRIPTION VARCHAR(255) NOT NULL,
ACTIVE INT NOT NULL,
PRIMARY KEY (ID)
);     




    INSERT INTO PRODUCT_STATUS(ID,DESCRIPTION,ACTIVE) VALUES (NULL,'ACTIVE',1);
    INSERT INTO PRODUCT_STATUS(ID,DESCRIPTION,ACTIVE) VALUES (NULL,'MISSING',1);
    INSERT INTO PRODUCT_STATUS(ID,DESCRIPTION,ACTIVE) VALUES (NULL,'DAMAGED',1);