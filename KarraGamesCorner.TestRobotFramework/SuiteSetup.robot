*** Settings ***
Documentation   Setup that runs before every testcase
Library     SeleniumLibrary

*** Variables ***
${url}  https://karragamecorner-development.azurewebsites.net/
${browser}      headlesschrome

*** Keywords ***

Open browser to website
    [Documentation]     Opens chrome and navigates to website
    [Tags]      Setup
    Open Browser    ${url}      ${browser}
    #Maximize Browser Window