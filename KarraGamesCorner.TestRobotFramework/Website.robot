#USE GHERKIN SYNTAX FOR ALL TEST CASES (GIVEN, WHEN, THEN)
#ALL TEST CASES SHOULD INCLUDE DOCUMENTATION AND TAGS

*** Settings ***

Documentation   Test website functionality
Library     SeleniumLibrary
Suite Setup     Open browser to website

Resource    SuiteSetup.robot
Resource    HeaderAndFooter.robot
Resource    StorePage.robot
Resource    CommunityPage.robot
Resource    AboutPage.robot
Resource    FrontPage.robot

*** Test Cases ***
Verify buttons in header on every page
    [Documentation]     Test that every link or button is visible in header on all pages
    [Tags]      Header
    Set Selenium Speed    0.5
    Given I'm at the Frontpage
    Then The header and all buttons should be visible
    When I navigate to Butik
    Then The header and all buttons should be visible
    When I navigate to Gemenskap
    Then The header and all buttons should be visible
    When I navigate to Om oss
    Then The header and all buttons should be visible
    When I navigate to Login
    Then The header and all buttons should be visible
    When I navigate back to Frontpage
    Then The header and all buttons should be visible

Add and remove item from cart
    [Documentation]     Test if add and remove finction from vart works as intended
    [Tags]      Cart
    Set Selenium Speed    0.5
    Given I've found a game I want to purchase
    When I add it to my cart
    And I navigate to the cart
    Then The game should've been added successfully
    And When I want to remove the item from my cart
    Then It should be removed from the cart

Use searchfield to search for a product
    [Documentation]     Test that completed search takes you to the product page
    [Tags]      Header
    Set Selenium Speed    0.5
    Given I'm at the frontpage
    When I search for a game
    And I click on the searchresult
    Then I am taken to that specific product page

Paymentflow
    [Documentation]     Tests the flow of finding a product and paying for it
    [Tags]      Payment
    Set Selenium Speed    0.5
    Given I've found what I want and am ready to pay
    When I fill out the form and click on Checkout  @{form_data}
    Then I'm taken to Klarna's checkout page

Footer Text
    [Documentation]     Assert the relevant footer text exists
    [Tags]      Footer
    Set Selenium Speed    0.5
    When I'm at the frontpage
    Then The relevant information should be displayed

Footer Links
    [Documentation]     Tests if links take you to the correct location
    [Tags]      Footer
    Set Selenium Speed    0.5
    Given I'm at the front page
    When I scroll down and click on Allmänna villkor
    Then I am taken to the page with KGC Allmänna villkor
    And When I go back and click on Evenemang
    Then I am take to the page with information about events

Register for an event
    [Documentation]     Test the flow of registering for an event
    [Tags]      Community
    Set Selenium Speed    0.5
    Given I'm at the Communitypage and find an event I want to sign up for
    When I click on Register now
    And I get taken to a form I fill out
    When I hit Register
    Then A popup with confirmation is displayed

Price adjustment in form depending on participants
    [Documentation]
    [Tags]      Community
    Set Selenium Speed    0.5
    Given I'm filling out the registration form
    When I adjust the number of participants the price changes

Error handling when field not filled out correctly
    [Documentation]     Fill out form without email adress should prompt an error
    [Tags]      Community
    Set Selenium Speed    0.5
    Given I'm filling out the registration form
    And I do not fill out email adress
    When I hit Register
    Then I should get an error

Relevant information in Aboutpage
    [Documentation]     Test that important information is visible in About page
    [Tags]      About
    Set Selenium Speed    0.5
    Given I navigate to Om oss
    When I locate the information I am looking for
    Then Opening hours, location, phone number and email adress should be visible

Slider link
    [Documentation]     Tests link in highlight banner
    [Tags]      Frontpage
    Set Selenium Speed    0.5
    Given I'm at the frontpage
    When I click on Mer Info button
    Then It takes me to a page with more information
    
Slider
    [Documentation]     Tests that all slider pages is visible
    [Tags]      Frontpage
    Set Selenium Speed    0.5
    Given I'm at the frontpage
    Then There should be three different slides when scrolling

Featured columns
    [Documentation]     Test checks if featured colums are present
    [Tags]      Frontpage
    Set Selenium Speed    0.5
    Given I'm at the frontpage
    When I scroll down the page
    Then I see three columns of highlighted products

Frontpage productlink
    [Documentation]     Test checks that links are working
    [Tags]      Frontpage
    Set Selenium Speed    0.5
    Given I'm at the frontpage
    When I click on a product
    Then It takes me to the correct product page

Verify at least 50 products is shown with price tags
    [Documentation]
    [Tags]  Store
    Set Selenium Speed    0.5
    Given I navigate to the StorePage
    Then There should be at least 50 products
    And The products should have price tags

Verify that a product have a description and add to cart button
    [Documentation]
    [Tags]  Store
    Set Selenium Speed    0.5
    Given I navigate to the StorePage
    When I click on the product
    Then There should be a product description
    And There should be an add to cart button

Added to cart popup is shown
    [Documentation]
    [Tags]  Cart
    Set Selenium Speed    0.5
    Given I navigate to the StorePage
    When I click add to cart
    Then There should be a popup

Test sorting function
    [Documentation]
    [Tags]  Sorting
    Set Selenium Speed    0.5
    Given I navigate to the StorePage
    Then There should be a sorting list
    When I click on sorting list and choose sort price increasing
    Then The products should be sorted accordingly to price increasing

Filter function is working
    [Documentation]
    [Tags]  Filter
    Set Selenium Speed    0.5
    Given I navigate to the StorePage
    Then There should be a category button
    When I click on category button
    Then There should be filter options
    When I click on a category
    Then The right games should show
