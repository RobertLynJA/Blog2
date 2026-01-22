
## Multi-stage Dockerfile to build a React app and serve the built /dist with NGINX

# 1) Builder: install deps and build to /app/dist
FROM node:25-alpine AS builder
WORKDIR /app

# Copy lockfile(s) and package.json for better layer caching
COPY src/react/package.json src/react/package-lock.json* ./

# Install dependencies
RUN npm ci

# Copy application source and build
COPY src/react .
RUN npm run build


# 2) Runtime: NGINX to serve static files
FROM nginx:1.29-alpine AS runtime

# Copy built assets from builder stage
COPY --from=builder /app/dist /usr/share/nginx/html

# Expose port 80 (default for NGINX)
EXPOSE 80

# Use default NGINX configuration which serves from /usr/share/nginx/html
# If you need SPA fallback or custom headers, add an nginx.conf and COPY it to /etc/nginx/conf.d/default.conf

COPY src/react/nginx.conf /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]
