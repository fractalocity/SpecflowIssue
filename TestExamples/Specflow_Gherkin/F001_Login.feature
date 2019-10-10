Feature: F001Login
	In order to ensure testers know how to use the login components
    The examples below show how to interact with the Login components

@AllCompanies @SmokeTest @AnotherTag
 Scenario: S001Validate Load of Home Page
	Given the user logs into yahoo
    When the user navigates to the Home page
    Then Home page components should be visible and no browser errors should exist

