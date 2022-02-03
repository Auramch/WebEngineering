import PropertySummary from "../models/property-summary.js";
import Property from "../models/property.js";
import apiCall from "./call.js";

export default{
    /**
     * 
     * Find a list of properties with the selected filters
     * @param {string} city
     * @returns {Promise<PropertySummary[]>}
     */
     async getProperties(city = null) {
        const apiResponse = await apiCall("properties", "GET", {
            city:city
        });

        // Very rudimentary error handling - you want to do something more
        // extensive here. For example: retry requests when a 5xx response
        // hits with exponential back-off, and for other requests
        // we would want to handle all "expected" error codes properly as
        // well and want to inform the user what went wrong.
        //
        // For example in the case of a POST request, the result might
        // be a validation error, then we want to show that to the user.
        if(!apiResponse.ok) throw new Error(await apiResponse.text());

        return (await apiResponse.json()).map(PropertySummary.fromJson);
    },

    /**
     * Finds a specific movie
     * 
     * @param {number} id 
     * @returns {Promise<Property>}
     */
    async getProperty(id) {
        const apiResponse = await apiCall(`properties/${id}`, "GET");
        if(!apiResponse.ok) throw new Error(await apiResponse.text());

        return Movie.fromJson(await apiResponse.json());
    },
}