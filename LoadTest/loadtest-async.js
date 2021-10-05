import { check } from 'k6';
import http from 'k6/http';
import { params } from './http-params.js';

export const options = {
    stages: [
        { duration: '30s', target: 3000 },
        { duration: '60s', target: 3000 }
    ]
};

export default function () {
    const response = http.get('http://AsyncAwaitDemo-600692485.us-east-1.elb.amazonaws.com/WeatherForecast/Async', params);
    check(response, { 'status was 200': (r) => r.status === 200 });
}