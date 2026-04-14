Feature: Login functionality

@login
Scenario Outline: Login with multiple users
  Given I navigate to login page
  When I login with "<username>" and "<password>"
  Then I should see "<result>"

Examples:
  | username        | password      | result      |
  | standard_user   | secret_sauce  | success     |
  | locked_out_user | secret_sauce  | error       |
  | wrong_user      | wrong_pass    | error       |