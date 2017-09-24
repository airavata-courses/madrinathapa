node {
    def app

    stage('Clone repository') {
        checkout scm
    }

    stage('Build image') {
        
    sh 'sudo docker stop greet || true && sudo docker rm greet || true'    
    sh 'sudo docker build -t madrinathapa/microservices:greet .'
    }
    stage('Deploy'){
        sh 'sudo docker run  --name greet -d madrinathapa/microservices:greet'
    }
}
