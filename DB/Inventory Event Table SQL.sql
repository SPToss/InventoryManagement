CREATE TABLE INVENTORY_EVENT(
ID INT NOT NULL AUTO_INCREMENT,
INVENTORY_ID INT NOT NULL,
EVENT_DATE TIMESTAMP NULL,
DESCRIPTION VARCHAR(255) NULL,
EVENT_TYPE_ID INT NOT NULL,
PRIMARY KEY (ID),
FOREIGN KEY (INVENTORY_ID) REFERENCES INVENTORY(ID)
);     