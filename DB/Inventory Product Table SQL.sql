CREATE TABLE INVENTORY_PRODUCT(
    ID INT NOT NULL AUTO_INCREMENT,
    INVENTORY_ID INT NOT NULL,
    ZONE_ID INT NOT NULL,
    SACANNED_DATE TIMESTAMP NOT NULL,
    PRODUCT_ID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (INVENTORY_ID) REFERENCES INVENTORY(ID),
    FOREIGN KEY (ZONE_ID) REFERENCES ZONE(ID),
    FOREIGN KEY (PRODUCT_ID) REFERENCES PRODUCT(ID)
);


CREATE INDEX INVENTORY_ID_INDEX ON INVENTORY_PRODUCT(INVENTORY_ID);

CREATE INDEX PRODUCT_ID_INDEX ON INVENTORY_PRODUCT(PRODUCT_ID);

CREATE INDEX ZONE_ID_INDEX ON INVENTORY_PRODUCT(ZONE_ID);