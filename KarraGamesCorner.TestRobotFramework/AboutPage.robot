*** Settings ***
Documentation   Resourcefile for aboutpage on website
Library     SeleniumLibrary
Library     OperatingSystem

*** Variables ***
${actual_opening_hours}
${actual_location_phonenumber_email}
${expected_opening_hours}
${expected_location_phonenumber_email}
${path_to_expected_opening_hours_file}      KarraGamesCorner.TestRobotFramework/expected_opening_hours.txt
${path_to_expected_location_phonenumber_email_file}     KarraGamesCorner.TestRobotFramework/expected_location_phonenumber_email.txt
*** Keywords ***
I locate the information I am looking for
    [Documentation]     Test that information is displayed
    [Tags]      About
    Sleep    1
    Scroll Element Into View    //div[@class='contact-text']
    Page Should Contain Element   //div[@class='open-times']    //div[@class='contact-text']
    ${actual_opening_hours}=   Get Text    //div[@class='open-times']
    ${actual_location_phonenumber_email}   Get Text    //div[@class='contact-text']
Opening hours, location, phone number and email adress should be visible
    Read expected texts
    Should Be Equal As Strings    ${actual_opening_hours}    ${expected_opening_hours}
    Should Be Equal As Strings    ${actual_location_phonenumber_email}    ${expected_location_phonenumber_email}
    Scroll Element Into View    //img[@src='logo_KGC_svart.png']

Read expected texts
    [Documentation]     Files containing testdata
    [Tags]      About
    ${expected_opening_hours}=  Get File    ${path_to_expected_opening_hours_file}
    ${expected_location_phonenumber_email}=     Get File    ${path_to_expected_location_phonenumber_email_file}