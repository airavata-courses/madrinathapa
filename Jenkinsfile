node {
    def app

    stage('Clone repository') {
        checkout scm
    }

    stage('Build image') {
        
    sh 'sudo docker stop gateway || true && sudo docker rm gateway || true'    
    sh 'sudo docker build -t madrinathapa/gateway:sga .'
    }
    stage('Deploy'){
        sh 'sudo docker run -p 58912:58912 --name gateway -d madrinathapa/gateway:sga'
    }
}
