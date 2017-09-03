from flask import Flask, jsonify
from flask import request

app = Flask(__name__)


@app.route('/getCircleArea', methods=['GET'])
def getCircleArea():
    radius = request.args.get('radius')

    area = 3.14*float(radius)*float(radius)
    return jsonify({'radius':radius,'area': area})


if __name__ == '__main__':
     app.run(port='8080')