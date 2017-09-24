node {
    def app

    stage('Clone repository') {
        checkout scm
    }

    stage('Build image') {
    sh 'docker stop sga || true && docker rm sga || true'
        app = docker.build("mthapa/gateway:sga")
    }
    stage('Deploy'){
        def c = docker.image('mthapa/gateway:sga').run('-p 58912:58912 --name sga')
    }
}
