node {
    def app

    stage('Clone repository') {
        checkout scm
    }

    stage('Build image') {
        
    sh 'sudo docker stop circle || true && sudo docker rm circle || true'    
    sh 'sudo docker build -t madrinathapa/microservices:circle .'
    }
    stage('Deploy'){
        sh 'sudo docker run  --name circle -d madrinathapa/microservices:circle'
    }
}
