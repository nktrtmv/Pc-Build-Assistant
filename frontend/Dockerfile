# Use an existing docker image as a base
FROM nginx:alpine

# Copy the index.html file to the nginx web server directory
COPY index.html /usr/share/nginx/html/

# Expose port 80 for incoming traffic
EXPOSE 80

# Set the command to run when the container is started
CMD ["nginx", "-g", "daemon off;"]
