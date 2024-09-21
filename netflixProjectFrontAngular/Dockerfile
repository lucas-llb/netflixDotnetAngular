
# Etapa 1: Construção da aplicação Angular
FROM node:18-alpine as build

WORKDIR /app

COPY package.json package-lock.json ./
RUN npm install

COPY . .
RUN npm run build

# Etapa 2: Servir a aplicação com Nginx
FROM nginx:alpine

COPY --from=build /app/dist/netflix-angular/browser/ /usr/share/nginx/html/

# Copiar configuração customizada do Nginx, se necessário
# COPY nginx-custom.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
