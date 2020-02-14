Feature: OnlineShop

@mytag
Scenario: Account creation
	Given I am in Sign In page
	When I enter email in Create New Account section
	And I enter valid account details
	And click on Register button
	And My Account page is opened
	And I click on My Personal Information button
	Then Your Personal Information page is opened
	And correct personal information is displayed

Scenario: Adding item to the cart
	Given I am in Sign In page
	When I enter email in Create New Account section
	And I enter valid account details
	And click on Register button
	And My Account page is opened
	And I click on My Personal Information button
	Then Your Personal Information page is opened
	And correct personal information is displayed

Given I am in Landing page
When I select Search menu
And I enter "Blouse"
And I click on Search button
And only 1 result is found
And I select the item
And item description and condition is displayed
And I change quantity to 2
And I set size to S
And I set color to White
And I select Add to cart button
And item is successfully added to cart
And I click on Proceed to checkout button
Then Shopping cart summary page is opened
And correct description is specified
And amount is correctly calculated
And Proceed to checkout button is visible
