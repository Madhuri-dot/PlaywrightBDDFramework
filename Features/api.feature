@api
Feature: API Testing

  Scenario: Get users
    When I send GET request to "https://jsonplaceholder.typicode.com/users"
    Then response status should be 200