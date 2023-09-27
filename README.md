# Clean Architecture + MVP

Источники использованные для решения задания

Clean Architecture
https://habr.com/ru/companies/otus/articles/732178/

Simplified Clean Architecture Design Pattern for Unity
https://genki-sano.medium.com/simplified-clean-architecture-design-pattern-for-unity-967931583c47

BUILD A MODULAR CODEBASE WITH MVC AND MVP PROGRAMMING PATTERNS
https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns#mvp-and-unity

*Пояснение:
В даном случае использование MVP паттерна в Presentation слое нарушает концепцию зависимостей Clean Architecture, т.к согласно Clean Architecture, UI уровень должен завсить от Presenter уровня(presrnter не знает о view), а согласно паттерну MVP - Presenter знает и управляет нашим view(UI).
В репозитории лежит два коммита с двумя способоми реализации

<img width="515" alt="Снимок экрана 2023-09-26 в 18 33 21" src="https://github.com/kaifarick/Calculator-Clean-Architecture/assets/66444648/97daaea4-5922-4403-aa24-7b90b301e789">
<img width="1529" alt="Снимок экрана 2023-09-26 в 18 28 41" src="https://github.com/kaifarick/Calculator-Clean-Architecture/assets/66444648/a57d2207-f09a-4399-8c3d-79f0d65f7e17">
