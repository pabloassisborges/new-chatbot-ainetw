#Dockerfile for flask containerization
FROM centos:latest
RUN yum update -y && yum clean all
RUN yum -y install epel-release && yum clean all
RUN yum -y install python-pip build-essentials python-dev && yum clean all
COPY . /app
WORKDIR /app
RUN pip install -r requirements.txt
ENTRYPOINT ["python"]
CMD ["app.py"]