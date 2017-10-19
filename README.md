# SDK Redirection for .Net Framework 4.5 

## Requerimientos
- SoapHttpClient >= v1.4.3
- Newtonsoft.Json >= 9.0.1

### Agregar dependencia en Visual Studio
Ir al explorador de soluciones, desplegar las opciones delproyecto y luego:

> Dependencias -> agregar referencia -> examinar -> examinar -> seleccionar dll -> Aceptar

----------

### Autenticación
Configurar instancia PlacetoPay necesaria para autenticarse ante los servicios web de PlacetoPay.

#### Config:

```csharp
using P2P = PlacetoPay.Integrations.Library.CSharp.PlacetoPay;
Gateway gateway = new P2P(YOUR_LOGIN, YOUR_TRANKEY, new Uri("URL_INTEGRATION"), Gateway.TP_SOAP or Gateway.TP_REST);
```
----------

### Crear una nueva sesión de pago
Solicita la creación de la sesión (petición de cobro o suscripción) y retorna el identificador y la URL de procesamiento.

#### Ejemplo de llamada:

```csharp
Amount amount = new Amount('PAYMENT_AMOUNT');
Payment payment = new Payment("REFERENCE", "DESCRIPTION", amount);
RedirectRequest request = new RedirectRequest(payment, RETURN_URL, IP_ADDRESS, USER_AGENT, EXPIRATION);
RedirectResponse response = gateway.Request(request);
```

#### Retorno: 
Servicio responde una instancia de la clase RedirectResponse. Verificando el status de la respuesta se puede determinar si se creó la session de pago.

### Success Response:
Si el status es igual a “OK” verifica

```csharp
response.IsSuccessful() // return boolean
```

#### Error Response:
Si el status es igual a “ERROR”. Verificar motivo del error

```csharp
response.Status.Message // return string
```

----------

### Obtenga información sobre una sesión
Obtiene la información de la sesión y transacciones realizadas. 

#### Ejemplo de llamada:

```csharp
RedirectInformation response = gateway.Query(requestId);
```

#### Retorno:
Servicio responde una instancia de la clase RedirectInformation. Se puede verificar el status de la sesión a través

```csharp
response.IsSuccessful() // return boolean
response.IsRejected() // return boolean
response.IsApproved() // return boolean
response.Status.status // return boolean
```

----------

### Cobro sin intervención del usuario
Permite realizar cobros sin la intervención del usuario usando medios de pago previamente suscritos.

#### Ejemplo de llamada:

```csharp
Token token = new Token(“YOUR_TOKEN”);
Instrument instrument = new Instrument(token);
Person person = new Person(dni, type, Name, Surname, email);
Amount amount = new Amount(1000);
Payment payment = new Payment("123456789", "TEST", amount);
CollectRequest collectRequest = new CollectRequest(person, payment, instrument);
RedirectInformation collect = this.gateway.Collect(collectRequest);
```

#### Retorno:
Servicio responde una instancia de la clase RedirectInformation. Se puede verificar el status de la sesión a través:

```csharp
response.IsSuccessful() // return boolean
response.IsRejected() // return boolean
response.IsApproved() // return boolean
response.Status.status // return boolean
```

----------

### Revertir un pago
Permite revertir un pago aprobado con el código de referencia interna. 

#### Ejemplo de llamada:

```csharp
ReverseResponse response = this.gateway.Reverse(requestId);
```

#### Retorno:
Servicio responde una instancia de la clase ReverseResponse. Se puede verificar el status de la sesión a través:

```csharp
response.IsSuccessful() // return boolean
response.Status.status // return boolean
```