*** Settings ***
Documentation   Resourcefile for header on website
Library     SeleniumLibrary

*** Variables ***

*** Keywords ***
I'm at the Frontpage
    [Documentation]     Test that all buttons and searchfield is visible on every page
    [Tags]  Buttons
    ${current_url}  Get Location
    ${homepage_url}  Set Variable  https://karragamecorner-development.azurewebsites.net/
    IF  '${current_url}' == '${homepage_url}'
    Return From Keyword
    END
    Scroll Element Into View    //img[@src='logo_KGC_svart.png']
    Click Element   //img[@src='logo_KGC_svart.png']
    Sleep    1
    Location Should Be    https://karragamecorner-development.azurewebsites.net/

The header and all buttons should be visible
    Wait Until Element Is Visible    //*[@id="header"]
    Element Should Be Visible    //input[@placeholder='SÖK PRODUKT...']     //a[@id='community-link']
    Element Should Be Visible    //a[@id='about-link']   //span[@id='login-button']
    Element Should Be Visible    //span[@id='wishlist-button']      //span[@id='cart-button']
    Element Should Be Visible    //a[@id='store-link']
I navigate to Butik
    Sleep    1
    Wait Until Element Is Visible   //a[@id='store-link']
    Click Element    //a[@id='store-link']
    Wait Until Element Is Visible    //h1[normalize-space()='KÄRRA GAMES CORNER SHOP']
I navigate to Gemenskap
    Sleep   1
    Wait Until Element Is Visible    //a[@id='community-link']
    Click Element    //a[@id='community-link']
    Wait Until Element Is Visible   //h1[@class='header-title']
I navigate to Om oss
    Sleep    1
    Scroll Element Into View    //a[@id='about-link']
    Wait Until Element Is Visible    //a[@id='about-link']
    Click Element    //a[@id='about-link']
    Wait Until Element Is Visible   //h3[normalize-space()='Om Oss']
I navigate to Login
    Click Element    //span[@id='login-button']
    Wait Until Element Is Visible   //h3[normalize-space()='Login']
I navigate back to Frontpage
    Click Element    //img[@src='logo_KGC_svart.png']
    Wait Until Element Is Visible  //div[@class='d-flex justify-content-center align-items-center']

I've found a game I want to purchase
    [Documentation]     Test adds product to cart and removes it
    [Tags]  Cart
    Wait Until Element Is Enabled   //a[@id='store-link']
    Click Element    //a[@id='store-link']
    Wait Until Element Is Visible    //div[@id='product-list']
I add it to my cart
    Sleep   3
    Scroll Element Into View    //div[1]//div[1]//div[2]//img[1]
    Mouse Over    //div[1]//div[1]//div[2]//img[1]
    Scroll Element Into View    //div[1]//div[1]//div[3]//div[3]//div[1]//button[1]//span[1]
    Click Element    //div[1]//div[1]//div[3]//div[3]//div[1]//button[1]//span[1]
I navigate to the cart
    Scroll Element Into View    //span[@id='cart-button']
    Mouse Over    //span[@id='cart-button']
    Sleep   1
    Click Element    //span[@id='cart-button']
    Wait Until Element Is Visible    //h1[normalize-space()='Kundkorg']
The game should've been added successfully
    Page Should Contain Element    //div[@class='item']
When I want to remove the item from my cart
    Click Element   //button[@id='cart-close-button']
It should be removed from the cart
    Page Should Contain Element    //p[@class='mt-3']
    Click Element    //button[@id='hide-cart-button']

I search for a game
    [Documentation]
    [Tags]
    Sleep    1
    Element Should Be Visible    //input[@placeholder='SÖK PRODUKT...']
    Input Text    //input[@placeholder='SÖK PRODUKT...']    Stardew Valley
I click on the searchresult
    Click Element    //div[@class='search-results']//ul//li
I am taken to that specific product page
    Page Should Contain Element    (//h1[normalize-space()='Stardew Valley'])[1]
    Page Should Contain Element    (//h3[normalize-space()='199.99 KR'])[1]

The relevant information should be displayed
    [Documentation]     Test that all relevant information is displayed
    [Tags]      Footer
    ${footer_text}=     Get Text    //div[@class='p-5']
    @{expected_texts}=    Create List       Kärra Games Corner      Evenemang       Kontakta oss
    FOR    ${expected_text}    IN    @{expected_texts}
        Should Contain    ${footer_text}    ${expected_text}
    END

I scroll down and click on Allmänna villkor
    [Documentation]
    [Tags]
    I'm at the Frontpage
    Scroll Element Into View    //div[@class='p-5']
    Click Element    //a[normalize-space()='Allmänna villkor']
I am taken to the page with KGC Allmänna villkor
    Wait Until Location Is    https://karragamecorner-development.azurewebsites.net/villkor
When I go back and click on Evenemang
    Go Back
    Wait Until Page Contains Element    //div[@class='p-5']
    Scroll Element Into View    //div[@class='p-5']
    Click Element    //a[normalize-space()='Evenemang']
I am take to the page with information about events
    Wait Until Location Is    https://karragamecorner-development.azurewebsites.net/community