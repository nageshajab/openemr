Step 1: register client for fhir using following link
https://localhost/interface/smart/register-app.php

Step 2: Select required scopes

Step 3: go to swagger for querying patient details using fhir and download ccda
https://localhost/swagger

Step 4: click 'Authorize' button

Step 5: enter client id & client secret

Step 6: select scopes needed

Step 7: click 'Authorize' button

step 8: it will redirect to 'https://localhost/oauth2/default/provider/login'

step 9: enter username: 'admin', password: 'pass'

Step 10: interface will allow you to select patient https://localhost/oauth2/default/smart/patient-select

Step 11: select patient, again select scopes
https://localhost/oauth2/default/scope-authorize-confirm

Step 12: again you will redirect back to swagger page

Step 13: try method 'GET -  9d223409-95fb-4b3f-8b24-f826a4899287
copy uuid from this line 
 "fullUrl": "https://localhost/apis/default/fhir/DocumentReference/9d223409-95fb-4b3f-8b24-f826a4899287",

Step 14: now open 'GET - fhir/binary/{id}'
 it will allow you to download CCDA
