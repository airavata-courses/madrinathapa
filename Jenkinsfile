node {
    def app

    stage('Clone repository') {
        checkout scm
    }

    stage('Build image') {
        
    sh 'sudo docker stop interface || true && sudo docker rm interface || true'    
    sh 'sudo docker build -t madrinathapa/ui:interface . '
    }
    stage('Deploy'){
        sh 'sudo docker run -p 3000:3000 --name interface -d madrinathapa/ui:interface'
    }
}
