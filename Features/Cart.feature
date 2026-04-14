@cart
Feature: Cart functionality

  Scenario: Add product to cart
    Given I login successfully
    When I add a product to cart
    And I open the cart
    Then product should be in cart

@checkout
Scenario: Complete checkout
  Given I login successfully
  When I add a product to cart
  And I open the cart
  And I proceed to checkout
  And I enter checkout details
  Then order should be successful