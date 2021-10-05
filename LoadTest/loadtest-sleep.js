import { check } from 'k6';
import http from 'k6/http';
import { params } from './http-params.js';

export const options = {
    stages: [
        { duration: '30s', target: 500 }
    ]
};

export default function () {
    const response = http.get('http://AsyncAwaitDemo-600692485.us-east-1.elb.amazonaws.com/WeatherForecast/Sleep', params);
    check(response, { 'status was 200': (r) => r.status === 200 });
}