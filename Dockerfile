# Use an official Python runtime as a parent image
FROM python:3.6.0

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
ADD . /app

# Install any needed packages specified in requirements.txt
RUN pip install -r requirements.txt

EXPOSE 5000 15672 5672 5671

ENTRYPOINT [ "python" ]

CMD [ "circleRabbitMQ.py" ]