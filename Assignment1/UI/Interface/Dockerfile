FROM node:8.2.1
WORKDIR /app
COPY package.json /app
RUN npm install
COPY . /app
CMD node server.js
