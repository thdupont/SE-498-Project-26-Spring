```mermaid
sequenceDiagram
    participant Browser as Website (Browser)
    participant Web as Web Server
	
    Browser->>Web: HTTP Request (Page / AJAX)
    Web-->>Browser: HTML / JSON Response
```
