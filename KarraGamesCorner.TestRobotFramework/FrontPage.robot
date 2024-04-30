*** Settings ***
Documentation
Library     SeleniumLibrary

*** Variables ***

*** Keywords ***
I look at the slider
    [Documentation]     Test that all slides are present
    [Tags]      Slider
    Scroll Element Into View    //img[@src='logo_KGC_svart.png']
    Click Element    //img[@src='logo_KGC_svart.png']
    Sleep    3
    Wait Until Element Is Visible    //div[@id='highlight']
There should be three different slides when scrolling
    Page Should Contain Element    //h1[normalize-space()='Speldag på Kärra Games Corner']
    Click Element    //button[@id='next-slide-button']
    Wait Until Element Is Visible    //h1[normalize-space()='Retrospelkväll på Kärra Games Corner']
    Click Element    //button[@id='next-slide-button']
    Wait Until Element Is Visible    //h1[normalize-space()='Kärra Games Corner']

I scroll down the page
    [Documentation]     Test that all columns are present
    [Tags]      Columns
    Sleep   1
    Scroll Element Into View    //div[@id='product-column']
I see three columns of highlighted products
    Page Should Contain Element    //div[@id='mest-sålda-column']
    Page Should Contain Element    //div[@id='kommande-column']
    Page Should Contain Element    //div[@id='vi-rekommenderar-column']

I click on a product
    [Documentation]     Test that products are linked correctly
    [Tags]      Columns
    Scroll Element Into View    //div[@id='mest-sålda-column']
    Click Element    //*[@id="mest-sålda-column"]/div[2]/div/div/h4     #Baldur's Gate 3
    Wait Until Element Is Visible    //*[@id="product-detail"]
It takes me to the correct product page
    Page Should Contain Element    //*[@id="viewing-product-name"]      #Baldur's Gate 3

I click on Mer Info button
    [Documentation]     Test that the slides in highlight banner is linked correctly
    [Tags]      Slider
    Sleep    1
    Scroll Element Into View    //button[@id='highlight-button-2']
    Click Element    //button[@id='highlight-button-2']     #Speldag på KGC
    Sleep    1
    Location Should Be    https://karragamecorner-development.azurewebsites.net/community/#holiday-gaming-event
    Scroll Element Into View    //img[@src='logo_KGC_svart.png']
It takes me to a page with more information
    Page Should Contain Element    //div[@id='holiday-gaming-event-text']
