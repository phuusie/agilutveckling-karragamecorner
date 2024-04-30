*** Settings ***
Documentation   Resourcefile for storepage on website
Library     SeleniumLibrary
Library    Collections
Resource    HeaderAndFooter.robot

*** Variables ***
@{form_data}    customer@email.se   Alice   Test    Södra Blasieholmshamnen 2   Stockholm   111 48  070-174 06 15
${card_number}  4111 1111 1111 1111
${card_expiration}  1228
${card_cvc}     123

${PRODUCT}        class=card

*** Keywords ***

I've found what I want and am ready to pay
    [Documentation]     Tests the whole flow of finding a product and checking out to Klarna
    [Tags]      Paymentflow
    I search for a game
    I click on the searchresult
    I am taken to that specific product page
    Click Element    //button[@id='add-to-cart-button']
    I navigate to the cart
    The game should've been added successfully
    Click Element    //button[@id='cart-checkout-buttom']
    Wait Until Element Is Visible    //div[@id='klarna-checkout-container']
When I fill out the form and click on Checkout
    [Arguments]     @{form_data}
    Input Text    //input[@id='emailAddress']    ${form_data}[0]
    Input Text    //input[@id='firstName']    ${form_data}[1]
    Input Text    //input[@id='lastName']    ${form_data}[2]
    Input Text    //input[@id='streetAddress']    ${form_data}[3]
    Input Text    //input[@id='city']    ${form_data}[4]
    Input Text    //input[@id='postalCode']    ${form_data}[5]
    Input Text    //input[@id='phoneNumber']    ${form_data}[6]
    Scroll Element Into View    //button[@id='checkout-button']
    Click Element    //input[@class='custom-checkbox']
    Click Element    //button[@id='checkout-button']
I'm taken to Klarna's checkout page
    Wait Until Page Contains Element    id=klarna-checkout-iframe   timeout=10s

I navigate to the StorePage
    [Documentation]
    [Tags]
    Page Should Contain Element    id=store-link
    Click Element    id=store-link
    Sleep    1s
There should be at least 50 products
    Page Should Contain Element    ${PRODUCT}
    Sleep    2s
    ${PRODUCT}    Get WebElements    ${PRODUCT}
    ${PRODUCT_count}    Get Length    ${PRODUCT}
    Run Keyword If    ${PRODUCT_count} >= 50    Log    At least 50 products are displayed on the website
...    ELSE    Fail    Less than 50 products are displayed on the website
The products should have price tags
    [Documentation]
    [Tags]
    ${products}    Get WebElements    ${PRODUCT}
    FOR    ${product}    IN    @{products}
        ${price}    Get Element Attribute    ${product}    class
        Run Keyword If    "'price-tag' in ${price}"    Log    Product price found for product ID: ${product.get_attribute('id')}
        ...    ELSE    Fail    No price tag found for product ID: ${product.get_attribute('id')}
    END

I click on the product
    [Documentation]
    [Tags]
    Wait Until Page Contains Element    ${PRODUCT}    5s
    Element Should Be Visible    ${PRODUCT}
    Click Element    ${PRODUCT}
    Sleep    1s
There should be a product description
    [Documentation]
    [Tags]
    ${product_description}=    Get Text    xpath://*[@id='viewing-product-description']
    Should Not Be Empty    ${product_description}
There should be an add to cart button
    [Documentation]
    [Tags]
    Page Should Contain Button    xpath://*[@id='add-to-cart-button']
I click add to cart
    [Documentation]
    [Tags]
    Click Element    ${PRODUCT}
    Page Should Contain Element    xpath://*[@id='add-to-cart-button']
    Sleep    1s
    Click Element    xpath://*[@id='add-to-cart-button']
    Sleep    1s
There should be a popup
    [Documentation]
    [Tags]
    Page Should Contain Element    xpath://div[@class='toast-header']

There should be a category button
    [Documentation]
    [Tags]
    Page Should Contain Button    xpath://button[@id='category-button']
    Sleep    1s
I click on category button
    [Documentation]
    [Tags]
    Element Should Be Visible    xpath://button[@id='category-button']
    Click Button    xpath://button[@id='category-button']
    Sleep    1s
There should be filter options
    [Documentation]
    [Tags]
    Element Should Be Visible    xpath://div[@class='category-box category-box fade-in']
I click on a category
    [Documentation]
    [Tags]
    Scroll Element Into View    xpath://label[@for='Sport']
    Click Element    xpath://label[@for='Sport']
    Sleep    2s
The right games should show
    [Documentation]
    [Tags]
    Scroll Element Into View    //*[@id="store-heading"]/h1
    Page Should Contain Element    //*[@id="product-list"]/div[1]
    Page Should Contain Element    //*[@id="product-list"]/div[2]

There should be a sorting list
    [Documentation]
    [Tags]
    Wait Until Page Contains Element    //div[@id='sort']
    Sleep    1s
When I click on sorting list and choose sort price increasing
    [Documentation]
    [Tags]
    Click Element    //div[@id='sort']
    Sleep    2s
    Click Element    xpath://*[text()='Pris stigande']
    Sleep    1s
The products should be sorted accordingly to price increasing
    [Documentation]
    [Tags]
    ${pricetags} =    Get WebElements    css=#price-tag
    ${filtered_prices} =    Create List
    FOR    ${price}    IN    @{pricetags}
        ${price_value} =    Get Text    ${price}
        Run Keyword If    "'Gratis' in ${price_value}"    Log    Found Gratis
            Append To List    ${filtered_prices}    ${price_value}
    END
    ${sorted_prices} =    Evaluate    sorted([float(price.replace(' KR', '')) if price != 'Gratis' else 0 for price in ${filtered_prices}])
    @{sorted_prices_list} =    Create List
    FOR    ${price}    IN    @{sorted_prices}
        Append To List    ${sorted_prices_list}    ${price}
    END