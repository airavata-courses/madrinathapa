node {
    def app

    stage('Clone repository') {
        checkout scm
    }

    stage('Build image') {
        
    sh 'sudo docker stop square || true && sudo docker rm square || true'    
    sh 'sudo docker build -t madrinathapa/microservices:square . '
    }
    stage('Deploy'){
        sh 'sudo docker run --name square -d madrinathapa/microservices:square'
    }
}
