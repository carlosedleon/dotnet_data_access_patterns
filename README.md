# Data Access Patterns in .NET

## Purpose
This repository explores trade-offs between different data access
strategies in .NET, focusing on performance, memory usage and maintainability.

## Patterns Compared
- EF Core SingleQuery (Include + JOIN)
- EF Core SplitQuery
- EF Core DTO Projection
- Dapper (SQL-first)

## What This Is Not
- Not a production-ready application
- Not a framework or template

## Why It Matters
Demonstrates cartesian explosion, query shaping, and when leaving EF Core
is justified based on measurements.
