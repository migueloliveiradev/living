FROM node:20.17-alpine as build

WORKDIR /app
COPY . .
RUN npm i
RUN npm run build

FROM node:20.17-alpine as production

WORKDIR /app
COPY --from=build /app/.nuxt ./.nuxt
COPY --from=build /app/.output ./.output

ENTRYPOINT [ "node", ".output/server/index.mjs" ]