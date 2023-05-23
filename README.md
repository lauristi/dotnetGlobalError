## dotnetGlobalError
### Estrutura de tratamento de erro global usando midleware e filter

```
Middleware
Exception Filters
Try-Catch
Ciclo de vida do pipeline e execução dos Middlewares
RequestDelegate next / await next(context);
```


Intenção:Criar uma estrutura capaz de lidar com todos os erros de uma aplicação
de forma centralizada.

Problema: Não é possivel criar um middleware para lidar com erros em endpoints de controllers
Solução criar um serviço de tratameno de erro que pode ser consumido por middleware e uma classe
para lidar com "exception filters"

Atenção!!!
Exemplo não funcional, apenas para estudo estrutural do código
Para melhorias futuras.



