# Сервис заметок Todo REST API, ASP.NET Core 8 и дополненный инфраструктурой

- Docker-контейнеризация

- База данных MongoDB

- Развёртывание в локальном Kubernetes - Minikube

- Настроенный CI/CD конвейер на GitHub Actions

- Автоматический деплой в кластер


## Развёртывание в Kubernetes (Minikube)

Запуск Minikube:     minicube start


Применение манифестов Kubernetes:      kubectl apply -f k8s/mongo.yaml     ,    kubectl apply -f k8s/todo-api.yaml


Доступ к API через сервис:      minikube service todo-api-service

## CI/CD конвейер GitHub Actions


### Build & Push

Сборка API

Публикация Docker-образа в Docker Hub

Проверка на ошибки

### Deploy

Выполняется на self-hosted runner

Разворачивает обновлённую версию приложения в Minikube
