CREATE TABLE Properties
(
    Id               VARCHAR(MAX)    NULL,
    external_id      VARCHAR(MAX)    NULL,
    area_raw         VARCHAR(MAX)    NULL,
    area_sqm         INT             NULL,
    city             VARCHAR(MAX)    NULL,
    cover_image_url  VARCHAR(MAX)    NULL,
    furnish          VARCHAR(MAX)    NULL,
    latitude         FLOAT           NULL,
    longitude        FLOAT           NULL,
    postal_code      VARCHAR(MAX)    NULL,
    postedAgo        VARCHAR(MAX)    NULL,
    propertyType     VARCHAR(MAX)    NULL,
    rawAvailability  VARCHAR(MAX)    NULL,
    rent             INT             NULL,
    rentDetail       VARCHAR(MAX)    NULL,
    rentRaw          VARCHAR(MAX)    NULL,
    source           VARCHAR(MAX)    NULL,
    title            VARCHAR(MAX)    NULL,
    url              VARCHAR(MAX)    NULL,
    additionalCosts  INT             NULL,
    additionalCostsRaw VARCHAR(MAX)        NULL,
    deposit          int             null,
    depositRaw       VARCHAR(MAX)    null,
    descriptionNonTranslated VARCHAR(MAX)    NULL,
    descriptionNonTranslatedRaw VARCHAR(MAX)    NULL,
    descriptionTranslated VARCHAR(MAX)    NULL,
    descriptionTranslatedRaw          VARCHAR(MAX)    NULL,
    energyLabel          VARCHAR(MAX)             null,
    gender          VARCHAR(MAX)    null,
    internet          VARCHAR(MAX)    NULL,
    isRoomActive     VARCHAR(MAX)    NULL,
    kitchen        VARCHAR(MAX)    NULL,
    living          VARCHAR(MAX)    NULL,
    matchAge             VARCHAR(MAX)    NULL,
    matchAgeBackup  VARCHAR(MAX)    NULL,
    matchCapacity          VARCHAR(MAX)    NULL,
    matchGender         FLOAT           NULL,
    matchGenderBackup        FLOAT           NULL,
    matchLanguages      VARCHAR(MAX)    NULL,
    matchStatus       VARCHAR(MAX)    NULL,
    matchStatusBackup     VARCHAR(MAX)    NULL,
    pageDescription  VARCHAR(MAX)    NULL,
    pageTitle             INT             NULL,
    pets             VARCHAR(MAX)    NULL,
    registrationCost        INT    NULL,
    registrationCostRaw   VARCHAR(MAX)    NULL,
    roommates            VARCHAR(MAX)    NULL,
    shower           VARCHAR(MAX)    NULL,
    smokingInside       VARCHAR(MAX)    NULL,
    toilet            VARCHAR(MAX)    NULL,
    userDisplayName  VARCHAR(MAX)    NULL,
    userId           VARCHAR(MAX)    NULL
);


SELECT * FROM JSON_TABLE(@json_document, '$[*]'
    COLUMNS (
    Id               VARCHAR(MAX)               PATH '$.Id',
    external_id      VARCHAR(MAX)               PATH '$.external_Id',
    area_raw         VARCHAR(MAX)               PATH '$.area_raw',
    area_sqm         INT                        PATH '$.area_sqm',
    city             VARCHAR(MAX)               PATH '$.city',
    cover_image_url  VARCHAR(MAX)               PATH '$.cover_image_url',
    furnish          VARCHAR(MAX)               PATH '$.furnish',
    latitude         FLOAT                      PATH '$.latitude',
    longitude        FLOAT                      PATH '$.longitude',
    postal_code      VARCHAR(MAX)               PATH '$.postal_code',
    postedAgo        VARCHAR(MAX)               PATH '$.postedAgo',
    propertyType     VARCHAR(MAX)               PATH '$.propertyType',
    rawAvailability  VARCHAR(MAX)               PATH '$.rawAvailability',
    rent             INT                        PATH '$.rent',
    rentDetail       VARCHAR(MAX)               PATH '$.rentDetail',
    rentRaw          VARCHAR(MAX)               PATH '$.rentRaw',
    source           VARCHAR(MAX)               PATH '$.source',
    title            VARCHAR(MAX)               PATH '$.title',
    url              VARCHAR(MAX)               PATH '$.url',
    additionalCosts  INT                        PATH '$.additionalCosts',
    additionalCostsRaw VARCHAR(MAX)             PATH '$.additionalCostsRaw',
    deposit          int                        PATH '$.deposit',
    depositRaw       VARCHAR(MAX)               PATH '$.depositRaw',
    descriptionNonTranslated VARCHAR(MAX)       PATH '$.descriptionNonTranslated',
    descriptionNonTranslatedRaw VARCHAR(MAX)    PATH '$.descriptionNonTranslatedRaw',
    descriptionTranslated VARCHAR(MAX)          PATH '$.descriptionTranslated',
    descriptionTranslatedRaw VARCHAR(MAX)       PATH '$.descriptionTranslatedRaw',
    energyLabel          VARCHAR(MAX)           PATH '$.energyLabel',
    gender          VARCHAR(MAX)                PATH '$.gender',
    internet          VARCHAR(MAX)              PATH '$.internet',
    isRoomActive     VARCHAR(MAX)               PATH '$.isRoomActive',
    kitchen        VARCHAR(MAX)                 PATH '$.kitchen',
    living          VARCHAR(MAX)                PATH '$.living',
    matchAge             VARCHAR(MAX)           PATH '$.matchAge',
    matchAgeBackup  VARCHAR(MAX)                PATH '$.matchAgeBackup',
    matchCapacity          VARCHAR(MAX)         PATH '$.matchCapacity',
    matchGender         FLOAT                   PATH '$.matchGender',
    matchGenderBackup        FLOAT              PATH '$.matchGenderBackup',
    matchLanguages      VARCHAR(MAX)            PATH '$.matchLanguages',
    matchStatus       VARCHAR(MAX)              PATH '$.matchStatus',
    matchStatusBackup     VARCHAR(MAX)          PATH '$.matchStatusBackup',
    pageDescription  VARCHAR(MAX)               PATH '$.pageDescription',
    pageTitle             INT                   PATH '$.pageTitle',
    pets             VARCHAR(MAX)               PATH '$.pets',
    registrationCost        INT                 PATH '$.registrationCost'L,
    registrationCostRaw   VARCHAR(MAX)          PATH '$.registrationCostRaw',
    roommates            VARCHAR(MAX)           PATH '$.roommates',
    shower           VARCHAR(MAX)               PATH '$.shower',
    smokingInside       VARCHAR(MAX)            PATH '$.smokingInside',
    toilet            VARCHAR(MAX)              PATH '$.toilet',
    userDisplayName  VARCHAR(MAX)               PATH '$.userDisplayName',
    userId           VARCHAR(MAX)               PATH '$.userId' 
    )
) AS json_table;
