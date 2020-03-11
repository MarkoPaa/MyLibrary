*** Settings ***
Library           SeleniumLibrary

*** Test Cases ***
TC_UI_1
    open browser    https://vaalikone.yle.fi/eduskuntavaali2019?lang=fi-FI    Chrome
    maximize browser window
    sleep    2s
    element should be visible    //*[@id="root"]/main/div[1]/section/div[2]/input
    press keys    //*[@id="root"]/main/div[1]/section/div[2]/input    hämeenlinna    RETURN
    click button    //*[@id="root"]/main/div[1]/section/button

TC_UI_2
    sleep    3s
    ${elementti1}    Get horizontal position    //*[@id="root"]/main/div[1]/div/article[1]/section[1]/div/div[1]
    log to console    elementti 1 tallennettu
    ${elementti2}    get horizontal position    //*[@id="root"]/main/div[1]/div/article[1]/section[2]/div/div[1]
    log to console    elementti 2 tallennettu
    should be equal    ${elementti1}    ${elementti2}

TC_UI_3
    sleep    2s
    click button    //*[@id="option_5"]
    sleep    2s
    click button    //*[@id="root"]/main/div[1]/div/button
    sleep    4s
    close browser
