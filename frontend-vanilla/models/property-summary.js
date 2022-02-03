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

export default class PropertySummary{
    /** @type {number} */
    id;

    /** @type {string} */
    title;

    /** @type {string} */
    availabilty;
    /**
     * Convert JSON to PropertySummary Instance
     * @param {object} json JSON
     * @returns {PropertySummary}
     */
    static fromJson(json){
        return Object.assign(new PropertySummary(),json);
    }
}