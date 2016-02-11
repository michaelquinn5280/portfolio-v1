var request = require('request-promise');
//var endpoint = 'http://localhost:3741/api/'
var endpoint = 'http://cvservices.azurewebsites.net/api/'

export function getPortfolio(referenceValue) {
    console.log('getPortfolio called with referenceValue: ', referenceValue);
    return request({ uri: endpoint + 'profileId?reference=' + referenceValue })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getContactInfo(profileId) {
   console.log('getContactInfo called with profileId: ', profileId);
    return request({ uri: endpoint + 'contactinfo/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getContactAttempts(profileId) {
    console.log('getContactAttempts called with profileId: ', profileId);
    return request({ uri: endpoint + 'contactattempt/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getGreeting(profileId) {
    console.log('getGreeting called with profileId: ', profileId);
    return request({ uri: endpoint + 'greeting/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getSiteInfo(profileId) {
    console.log('getSiteInfo called with profileId: ', profileId);
    return request({ uri: endpoint + 'siteinfo/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getLegal(profileId) {
    console.log('getLegal called with profileId: ', profileId);
    return request({ uri: endpoint + 'copyright/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getProfile(profileId) {
    console.log('getProfile called with profileId: ', profileId);
    return request({ uri: endpoint + 'profile/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}

export function getProjects(profileId) {
    console.log('getProfile called with profileId: ', profileId);
    return request({ uri: endpoint + 'projects/' + profileId })
    .then(function (result) {
        console.log('result: ', result);
        var parsedResult = JSON.parse(result)
        console.log('result object: ', parsedResult);
        return parsedResult;
    });
}