# Gestión de Catálogo y Órdenes

Reto técnico desarrollado con .NET 8, Angular y SQL Server usando Clean Architecture y diseño orientado a microservice.

---

# Descripción General

Esta solución permite autenticar usuarios para:

- Gestionar categorias
- Gestionar productos
- Crear ordenes
- Validar stock
- Procesar ordenes a través de servicio interno

La aplicación demuestra:
- Clean Architecture
- Separación de responsabilidades
- Autenticación JWT
- Comunicación interna de la API
- Validación de negocio
- Persistencia en SQL Server

---

# Arquitectura

Estructura de la solución:

```txt
CatalogOrder.Domain
CatalogOrder.Application
CatalogOrder.Infrastructure
CatalogOrder.Api
OrderProcessingService
catalog-order-web
```

---

# Arquitectura Backend

El backend sigue principios de Clean Architecture:

```txt
Presentation Layer
↓
Application Layer
↓
Domain Layer
↓
Infrastructure Layer
```

Las Responsabilidades son separadas para mejorar:
- mantenibilidad
- escalabilidad

---

# Microservice Communication

La solución incluye un servicio de procesamiento interno:

```txt
Angular Frontend
↓
CatalogOrder.Api
↓
OrderProcessingService
↓
SQL Server
```

El servicio interno es responsable de:
- Validar stock
- Calcular ordenes
- Reglas del proceso de negocio

---

# Tecnologias

## Backend
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger

## Frontend
- Angular 18
- Angular Material
- Reactive Forms

---

# Features

## Autenticación 
- JWT login
- Route protection
- HTTP interceptor

## Categorias
- Crear categorias
- Listar categorias

## Productos
- Crear productos
- Buscar productos

## Ordenes
- Crear orders
- Cart management
- Cálculo total
- Validación de stock
- Procesamiento interno

---

# Seguridad

La solución está implementado con:

- JWT Authentication para solicitudes del cliente
- Protección de API Key interna entre servicios
- Protección de endpoints con atributo Authorize

---

# Regla de Negocio

El sistema valida:

- Si los productos deben existir
- Si los productos deben estar activos
- La cantidad debe ser mayor que 0
- El stock debe ser suficiente

---

# Corriendo la solución

## 1. Clonar repositorio

```bash
git clone https://github.com/NattoGaboh/RetoTecnicoVik.git
```

---

## 2. Configura cadena de conexión de SQL Server

Update:

```txt
appsettings.Development.json
```

---

## 3. Aplica migración

```bash
dotnet ef database update
```

---

## 4. Corre APIs backend

Run:

```txt
CatalogOrder.Api
OrderProcessingService
```

---

## 5. Corre frontend Angular

```bash
npm install

ng serve
```

---

# Default URLs

## Frontend

```txt
http://localhost:4200
```

## API Principal

```txt
https://localhost:5165
```

## Servicio de Procesamiento Interno

```txt
https://localhost:5223
```

---

# Autenticación

Ejemplo de credenciales:

```txt
username: admin
password: Admin321
```

---

# Decisiones de diseño

## Por qué Clean Architecture?

Para separar:
- Reglas de negocio
- Infraestructura
- Lógica de la aplicación
- Peresentación

Esto mejora la mantenibilidad y el testeo.

---

## ¿Por qué un servicio interno de procesamiento?

Para aislar:
- Cálculo de pedidos
- Validación de inventario
- Lógica de procesamiento de negocio

Esto mantiene la API principal ligera y enfocada.

---

# Futuras mejoras

Posibles futuras mejoras:
- Mejor diseño frontend
- Soporte para Docker
- Test Unitarios
- Test de integración
- Refresh tokens
- Administración de roles
- Historial de ordenes
- Caché Redis
- Pipeline CI/CD
