export class Location{
    /**@type {string} */
    city;
    /**@type {string} */
    latitude;
    /**@type {string} */
    longitude;
    /**@type {string} */
    postalCode;
    /**
     * Convert from JSON to Review instance
     * @param {object} json JSON from API
     * @returns {Location}
     */
    static fromJson(json) {
        return Object.assign(new Location(), json);
        }
}

export class RoomInfo{
    /**@type {number} */
    areaSqm;
    /**@type {string} */
    furnish;
    /**@type {string} */
    propertyType;
    /**@type {string} */
    energyLabel;
    /**
     * Convert from JSON to Review instance
     * @param {object} json JSON from API
     * @returns {RoomInfo}
     */
    static fromJson(json) {
        return Object.assign(new RoomInfo(), json);
        }
}

export class Costs{
    /**@type {number} */
    rent;
    /**@type {number} */
    additionalCosts;
    /**@type {number} */
    deposit;
    /**
     * Convert from JSON to Review instance
     * @param {object} json JSON from API
     * @returns {Costs}
     */
    static fromJson(json) {
        return Object.assign(new Costs(), json);
        }
}

export class Description{
    /**@type {string} */
    nonTranslatedDescription;
    /**@type {string} */
    translatedDescription;
    /**
     * Convert from JSON to Review instance
     * @param {object} json JSON from API
     * @returns {Description}
     */
    static fromJson(json) {
        return Object.assign(new Description(), json);
        }
}

export class Allowances{
    /**@type {string} */
    pets;
    /**@type {string} */
    smokingInside;
    /**
     * Convert from JSON to Review instance
     * @param {object} json JSON from API
     * @returns {Allowances}
     */
    static fromJson(json) {
        return Object.assign(new Allowances(), json);
        }
}

export class Commodities{
    /**@type {string} */
    internet;
    /**@type {string} */
    living;
    /**@type {string} */
    shower;
    /**@type {string} */
    kitchen;
    /**@type {string} */
    toilet;
    /**
     * Convert from JSON to Review instance
     * @param {object} json JSON from API
     * @returns {Commodities}
     */
    static fromJson(json) {
        return Object.assign(new Commodities(), json);
        }
}

export default class Property{
    /**@type {number} */
    id;
    /**@type {string} */
    postedAgo;
    /**@type {string} */
    roommates;
    /**@type {string} */
    isRoomActive;
    /**@type {string} */
    gender;
    /**@type {string} */
    availability;
    /**@type {string} */
    url;
    /**@type {string} */
    title;
    /**@type {Location} */
    location;
    /**@type {RoomInfo} */
    roomInfo;
    /**@type {Costs} */
    costs;
    /**@type {Description} */
    description;
    /**@type {Allowances} */
    allowances;
    /**@type {Commodities} */
    commodities;

    /**
     * Converts from JSON to Property instance
     * @param {object} json JSON from API
     * @returns {Property}
     */
    static fromJson(json){
        let property=new Property();
        property.id=json.id;
        property.postedAgo=json.postedAgo;
        property.roommates=json.roommates;
        property.isRoomActive=json.isRoomActive;
        property.gender=json.gender;
        property.availability=json.availability;
        property.url=json.url;
        property.title=json.title;
        property.location=Location.fromJson(json.location);
        property.roomInfo=RoomInfo.fromJson(json.roomInfo);
        property.costs=Costs.fromJson(json.costs);
        property.description=Description.fromJson(json.description);
        property.allowances=Allowances.fromJson(json.allowances);
        property.commodities=Commodities.fromJson(json.commodities);

        return property;
    }
}