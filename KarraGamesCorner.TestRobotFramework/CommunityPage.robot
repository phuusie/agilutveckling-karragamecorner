*** Settings ***
Documentation   Resourcefile for communitypage on website
Library     SeleniumLibrary
Library    Collections

*** Variables ***

*** Keywords ***

I'm at the Communitypage and find an event I want to sign up for
    [Documentation]     Test the flow of finding an event and signing up for it
    [Tags]      Signup
    Wait Until Element Is Visible    //a[@id='community-link']
    Sleep    3
    Scroll Element Into View    //a[@id='community-link']
    Click Element    //a[@id='community-link']
    Scroll Element Into View    //div[@id='holiday-gaming-event-text']
    Element Should Be Visible    //h2[normalize-space()='Inbjudan till Speldag på Kärra Games Corner']
I click on Register now
    Click Element    //div[@id='sign-up-button2']
    Element Should Be Visible    //div[@id='sign-up-form']
I get taken to a form I fill out
    Sleep   1
    Scroll Element Into View    //div[@id='sign-up-form']
    Select From List By Label    //select[@id='eventName']      Speldag på Kärra Games Corner
    Input Text    //input[@type='number']    10
    Input Text    //input[@type='email']    test@test.com
I hit Register
    Scroll Element Into View    //button[normalize-space()='Skicka anmälan']
    Click Element    //button[normalize-space()='Skicka anmälan']
    Sleep    1
A popup with confirmation is displayed
    Page Should Contain Element    //div[@class='popup']
    Click Element   //*[@id="popup-element"]/div/button

I'm filling out the registration form
    [Documentation]     Test that the price column reflects the correct price
    [Tags]  Signup
    I'm at the Communitypage and find an event I want to sign up for
    Scroll Element Into View    //div[@id='sign-up-form']
    Select From List By Label    //select[@id='eventName']      Speldag på Kärra Games Corner
I adjust the number of participants the price changes
    ${previous_price}    Set Variable    ${EMPTY}
    @{participants}     Create List      3   7  10
    FOR    ${participant}    IN    @{participants}
        Clear Element Text    //input[@type='number']
        Input Text    //input[@type='number']    ${participant}
        ${current_price}    Get Value    //*[@id="price"]
        Should Not Be Equal    ${previous_price}    ${current_price}
        Set Variable    ${previous_price}    ${current_price}
    END

I do not fill out email adress
    [Documentation]     Test error-handling in signup form
    [Tags]      Signup
    Clear Element Text    //input[@type='email']
I should get an error
    Element Attribute Value Should Be    //input[@type='email']    Required    true