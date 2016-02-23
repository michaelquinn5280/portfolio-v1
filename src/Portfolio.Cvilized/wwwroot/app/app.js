!function(){"use strict";angular.module("portfolioApp",["ngRoute","ngResource","ngAnimate","legalService","profileService","greetingService","projectsService","contactInfoService","contactAttemptService","siteInfoService","ui.bootstrap","easypiechart"]).config(["$httpProvider",function(a,b){a.interceptors.push("portfolioHttpInterceptor")}]).factory("portfolioHttpInterceptor",["$location",function(a){return{request:function(b){if(b.url.match("api")){var c="http://cvservices.azurewebsites.net/",d=a.host();"localhost"==d&&(c="http://localhost:3741/"),b.url=c+b.url}return b}}}])}(),function(){"use strict";function a(a,b,c,d){a.isSendContactSaving=!1,a.sendContactAttempt=function(){a.isSendContactSaving=!0,c.query({reference:b.host()},function(b){var c={ProfileId:b.ProfileId,Name:a.formContact.Name,EmailAddress:a.formContact.EmailAddress,Subject:a.formContact.Subject,Message:a.formContact.Message};d.send({profileId:b.ProfileId},c).$promise.then(function(b){b?(a.isSendContactSaving=!1,a.formContact.Name="",a.formContact.EmailAddress="",a.formContact.Subject="",a.formContact.Message=""):a.isSendContactSaving=!1})})}}angular.module("portfolioApp").controller("contactAttemptController",a),a.$inject=["$scope","$location","ProfileReference","ContactAttempt"]}(),function(){"use strict";var a=angular.module("contactAttemptService",["ngResource"]);a.factory("ContactAttempt",["$resource",function(a){return a("api/contactattempt/:profileId",{profileId:"@profileId"},{send:{method:"POST"}})}])}(),function(){"use strict";function a(){var a={restrict:"EA",templateUrl:"html/test.html"};return a}angular.module("portfolioApp").directive("contactsendsubmit",a)}(),function(){"use strict";function a(a,b,c,d){c.query({reference:b.host()},function(b){a.contactInfo=d.query({profileId:b.ProfileId})})}angular.module("portfolioApp").controller("contactInfoController",a),a.$inject=["$scope","$location","ProfileReference","ContactInfo"]}(),function(){"use strict";var a=angular.module("contactInfoService",["ngResource"]);a.factory("ContactInfo",["$resource",function(a){return a("api/contactinfo/:profileId",{profileId:"@profileId"},{query:{method:"GET",params:{},isArray:!1}})}])}(),function(){"use strict";function a(a,b,c,d){c.query({reference:b.host()},function(b){a.greeting=d.query({profileId:b.ProfileId})})}angular.module("portfolioApp").controller("greetingController",a),a.$inject=["$scope","$location","ProfileReference","Greeting"]}(),function(){"use strict";var a=angular.module("greetingService",["ngResource"]);a.factory("Greeting",["$resource",function(a){return a("api/greeting/:profileId",{profileId:"@profileId"},{query:{method:"GET",params:{},isArray:!1}})}])}(),function(){"use strict";function a(a,b,c,d){c.query({reference:b.host()},function(b){a.copyright=d.query({profileId:b.ProfileId})})}angular.module("portfolioApp").controller("legalController",a),a.$inject=["$scope","$location","ProfileReference","Copyright"]}(),function(){"use strict";var a=angular.module("legalService",["ngResource"]);a.factory("Copyright",["$resource",function(a){return a("api/copyright/:profileId",{profileId:"@profileId"},{query:{method:"GET",params:{},isArray:!1}})}])}(),function(){"use strict";function a(a,b,c){a.items=["Mobile First responsive design","Bootstrap with CVilized wrapper","AngularJs","ASP.NET 5 Preview Templates",c.trustAsHtml('<a class="modal-link" href="http://cvservices.azurewebsites.net/help" target="_blank">Web API</a> with .NET 4.6'),c.trustAsHtml('Queryable <a class="modal-link" href="http://cvgraphql.azurewebsites.net/" target="_blank">GraphQL</a> endpoint'),"Application Insights","MongoLab Data",c.trustAsHtml('Continuous Integration with <a class="modal-link" href="https://github.com/michaelquinn5280/Portfolio" target="_blank">GitHub</a> and Azure')],a.title="SUMMARY",a.link="",a.animationsEnabled=!0,a.open=function(c){var d=b.open({animation:a.animationsEnabled,templateUrl:"aboutSiteModalContent.html",controller:"modalInstanceController",size:c,resolve:{items:function(){return a.items},title:function(){return a.title},link:function(){return a.link}}});d.result.then(function(b){a.selected=b},function(){})},a.toggleAnimation=function(){a.animationsEnabled=!a.animationsEnabled}}angular.module("portfolioApp").controller("aboutSiteModalController",a),a.$inject=["$scope","$modal","$sce"]}(),function(){"use strict";function a(a,b,c){a.items=[],a.title="",a.companyUrl="",a.animationsEnabled=!0,a.open=function(d,e,f,g){a.items=e,a.title=f,a.link=c.trustAsHtml(g);var h=b.open({animation:a.animationsEnabled,templateUrl:"experienceModalContent.html",controller:"modalInstanceController",size:d,resolve:{items:function(){return a.items},title:function(){return a.title},link:function(){return a.link}}});h.result.then(function(b){a.selected=b},function(){})},a.toggleAnimation=function(){a.animationsEnabled=!a.animationsEnabled}}angular.module("portfolioApp").controller("experienceModalController",a),a.$inject=["$scope","$modal","$sce"]}(),function(){"use strict";function a(a,b,c,d,e){a.items=c,a.title=d,a.link=e,a.selected={item:a.items[0]},a.ok=function(){b.close(a.selected.item)},a.cancel=function(){b.dismiss("cancel")}}angular.module("portfolioApp").controller("modalInstanceController",a),a.$inject=["$scope","$modalInstance","items","title","link"]}(),function(){"use strict";function a(a){a.options={animate:{duration:2e3,enabled:!0},barColor:"#CF5037",trackColor:"#545454",size:180,scaleColor:!1}}angular.module("portfolioApp").controller("pieChartController",a),a.$inject=["$scope"]}(),function(){"use strict";function a(a,b,c,d){d.query({reference:b.host()},function(b){a.profile=c.query({profileId:b.ProfileId})})}angular.module("portfolioApp").controller("profileController",a),a.$inject=["$scope","$location","Profile","ProfileReference"]}(),function(){"use strict";var a=angular.module("profileService",["ngResource"]);a.factory("Profile",["$resource",function(a){return a("api/profile/:profileId",{profileId:"@profileId"},{query:{method:"GET",params:{},isArray:!1}})}]),a.factory("ProfileReference",["$resource",function(a){return a("api/profileId/",{},{query:{method:"GET",params:{reference:"@reference"},isArray:!1}})}])}(),function(){"use strict";function a(a,b,c,d){c.query({reference:b.host()},function(b){a.projects=d.query({profileId:b.ProfileId}),a.timelineBuckets=function(){var b=[];return angular.forEach(a.projects,function(a){-1==b.indexOf(a.endYear())&&b.push(a.endYear())}),b}})}angular.module("portfolioApp").controller("projectsController",a),a.$inject=["$scope","$location","ProfileReference","Projects"]}(),function(){"use strict";angular.module("portfolioApp").filter("withProjectEndDate",function(){return function(a,b){var c=[];return angular.forEach(a,function(a){a.endYear()==b&&c.push(a)}),c}})}(),function(){"use strict";var a=angular.module("projectsService",["ngResource"]);a.factory("Projects",["$resource","$filter",function(a,b){var c=a("api/projects/:profileId",{profileId:"@profileId"},{query:{method:"GET",params:{},isArray:!0}});return c.prototype.endYear=function(){return b("date")(this.EndDate,"yyyy")},c}])}(),function(){"use strict";function a(a,b,c,d){c.query({reference:b.host()},function(b){a.siteInfo=d.query({profileId:b.ProfileId})})}angular.module("portfolioApp").controller("siteInfoController",a),a.$inject=["$scope","$location","ProfileReference","SiteInfo"]}(),function(){"use strict";var a=angular.module("siteInfoService",["ngResource"]);a.factory("SiteInfo",["$resource",function(a){return a("api/siteinfo/:profileId",{profileId:"@profileId"},{query:{method:"GET",params:{},isArray:!1}})}])}();